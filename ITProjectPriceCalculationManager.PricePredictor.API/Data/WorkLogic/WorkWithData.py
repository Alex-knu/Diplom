import os
import logging

import pandas as pd
import mysql.connector as connection

from Settings import Constants as constant

constant.Log_file = logging.getLogger("Validation")


def Load_data_db():
    mydb = connection.connect(
        host=constant.config["DataBase"]["host"],
        port=constant.config["DataBase"]["port"],
        user=constant.config["DataBase"]["user"],
        password=constant.config["DataBase"]["password"],
        database=constant.config["DataBase"]["database"]
    )

    return pd.read_sql(constant.Sql_query, mydb)


def Load_data_csv(path):
    return pd.read_csv(path, sep=',')


def Sinhronize_data(etalon, data):
    missing_columns = []
    for item in data.columns:
        if item not in etalon.columns and item != 'Price':
            missing_columns.append(item)

    return data.drop(columns=list(missing_columns))


def Change_item_colum(data_frame):
    data_frame['CityName'] = list(map(lambda city_name: float(constant.Cities[city_name]), data_frame['CityName']))
    data_frame['Specialization'] = list(map(
        lambda specialization: float(constant.Specializations[specialization]) if specialization is not None else None,
        data_frame['Specialization']))
    data_frame['UniversityName'] = list(map(lambda university_name: float(constant.University[university_name]),
                                            data_frame['UniversityName']))
    data_frame.fillna(0)

    return data_frame


def Select_university_with_price(data_frame, is_full_time_education):
    return data_frame.loc[
        data_frame['Price'] is not None and data_frame['EducationType'] == int(is_full_time_education)]


def Delete_columns_without_info(data_frame):
    missing_data_frame = Missing_values_table(data_frame)
    missing_columns = list(missing_data_frame[missing_data_frame['% до загальних значень'] > 50].index)
    constant.Log_file.info('Було видалено %d колонок.' % len(missing_columns))

    return data_frame.drop(columns=list(missing_columns))


def Missing_values_table(data_frame):
    mis_val = data_frame.isnull().sum()
    mis_val_percent = 100 * data_frame.isnull().sum() / len(data_frame)
    mis_val_table = pd.concat([mis_val, mis_val_percent], axis=1)
    mis_val_table_ren_columns = mis_val_table.rename(columns={0: 'Відсутні значення', 1: '% до загальних значень'})
    mis_val_table_ren_columns = mis_val_table_ren_columns[mis_val_table_ren_columns.iloc[:, 1] != 0].sort_values(
        '% до загальних значень', ascending=False).round(1)

    constant.Log_file.info(f'''В датафреймі {data_frame.shape[1]} колонок.
                           В {mis_val_table_ren_columns.shape[0]} колонках відсутні значення.''')

    return mis_val_table_ren_columns


def Create_matrix_from_data_frame(data_frame):
    data = data_frame.iloc[:, :-1].values
    price = data_frame.iloc[:, len(data_frame.columns) - 1].values

    return data, price


def Load_result_to_csv(dictionary, time):
    if not os.path.isdir(f'ML/Result/{time}'):
        os.makedirs(f'ML/Result/{time}')

    data_frame = pd.DataFrame(dictionary)
    data_frame.to_csv(f'ML/Result/{time}/Result.csv')


def Initialize_data(source_type, is_full_time_education, is_predict_data, path=None):
    data_frame = pd.DataFrame()
    if source_type == 'csv':
        data_frame = Load_data_csv(path)
    elif source_type == 'db':
        data_frame = Load_data_db()

    if not is_predict_data:
        data_frame = Change_item_colum(Delete_columns_without_info(
            Select_university_with_price(data_frame, is_full_time_education)))
    else:
        data_frame = Change_item_colum(data_frame)

    return data_frame
