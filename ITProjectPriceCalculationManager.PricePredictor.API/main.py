import datetime
from sklearn.linear_model import LinearRegression, BayesianRidge, ElasticNet, Ridge

from Settings.Constants import config
from Graphics.Create_Graph import Clear_data_and_save_graph
from ML.ML_Methods import Regression, Select_best_model, result
from Data.WorkLogic.WorkWithData import Initialize_data, Create_matrix_from_data_frame, Load_result_to_csv, \
    Sinhronize_data


def Create_regression_models(data_frame, alpha):
    data, price = Create_matrix_from_data_frame(data_frame)

    Regression(LinearRegression(), data, price, 'LinearRegression', float('{:.3f}'.format(alpha)))
    Regression(BayesianRidge(), data, price, 'BayesianRidge', float('{:.3f}'.format(alpha)))
    Regression(ElasticNet(), data, price, 'ElasticNet', float('{:.3f}'.format(alpha)))
    Regression(Ridge(), data, price, 'Ridge', float('{:.3f}'.format(alpha)))


def Analise_data(data_frame, time, apply_data_cleansing, alpha):
    tmp_data_frame = Clear_data_and_save_graph(data_frame, time, apply_data_cleansing, float('{:.3f}'.format(alpha)))

    if len(tmp_data_frame.columns.tolist()) <= 1:
        print('Дані є не повними')
        return False

    Create_regression_models(tmp_data_frame, alpha)


def Predict(model, train_frame, predict_frame):
    train_frame = Clear_data_and_save_graph(train_frame, time, True, float('{:.3f}'.format(alpha)))
    predict_frame = Sinhronize_data(train_frame, predict_frame)
    predict_data = predict_frame.iloc[:, :].values
    return model.predict(predict_data)


def Start_ml(data_frame, time, apply_data_cleansing, alpha):
    if apply_data_cleansing is False:
        continue_analise = Analise_data(data_frame, time, apply_data_cleansing, 1 - alpha)
    else:
        while alpha != 0:
            continue_analise = Analise_data(data_frame, time, apply_data_cleansing, 1 - alpha)

            if continue_analise is False:
                break

            alpha = alpha - 0.1

    Load_result_to_csv(result, time)

    return Select_best_model()


if __name__ == '__main__':
    alpha = 1.0
    apply_data_cleansing = bool(config["Data"]["apply_data_cleansing"])
    time = datetime.datetime.now()
    train_frame = Initialize_data(config["Data"]["form"], apply_data_cleansing, False)
    # print(train_frame)
    predict_frame = Initialize_data('csv', apply_data_cleansing, True, 'Data/Set/Result_4.csv')
    train_frame = Sinhronize_data(predict_frame, train_frame)
    model, alpha = Start_ml(train_frame, time, apply_data_cleansing, alpha)

    result = Predict(model, train_frame, predict_frame)

    print(f'Прогнозована ціна: {float("{:.2f}".format(result[0]))} грн.')
