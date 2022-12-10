import os
import logging
import numpy as np
import matplotlib.pyplot as plt
from sklearn.metrics import r2_score

from Settings.Constants import Log_file

log_file = logging.getLogger("Graphics")


def Print_figure(x, y, my_model):
    figure = plt.figure()
    my_line = np.linspace(1, max(x) + 1, 200)

    plt.scatter(x, y)
    plt.plot(my_line, my_model(my_line))
    plt.grid(True)
    plt.ylim([0, max(y) + 1000])

    return figure


def Save_figure(x, y, my_model, column_name, time, alfa):
    fig = Print_figure(x, y, my_model)
    fig.savefig(f'Graphics/Result/{time}/{alfa}/{column_name}-Price.png')


def Check_relations_in_data(x, y, my_model, column_name, time, alfa, defect_columns):
    if r2_score(y, my_model(x)) > alfa or r2_score(y, my_model(x)) < -1 * alfa:
        Save_figure(x, y, my_model, column_name, time, alfa)
    else:
        Log_file.info(f'Data: {time}. Not plotted {alfa}/{column_name}-Price')
        defect_columns.append(column_name)


def Prepare_data_for_graph(x, y, column_name, time, apply_data_cleansing, alfa, defect_columns):
    my_model = np.poly1d(np.polyfit(x, y, 4))

    if not os.path.isdir(f'Graphics/Result/{time}'):
        os.makedirs(f'Graphics/Result/{time}')

    if not os.path.isdir(f'Graphics/Result/{time}/{alfa}'):
        os.makedirs(f'Graphics/Result/{time}/{alfa}')

    if apply_data_cleansing is False:
        Save_figure(x, y, my_model, column_name, time, alfa)
    else:
        Check_relations_in_data(x, y, my_model, column_name, time, alfa, defect_columns)


def Clear_data_and_save_graph(data_frame, time, apply_data_cleansing, alfa):
    defect_columns = []
    price = data_frame.iloc[:, len(data_frame.columns) - 1].values.tolist()
    data_top = data_frame.columns.tolist()

    for item in range(len(data_top) - 1):
        Prepare_data_for_graph(data_frame.iloc[:, item].values.tolist(), price, data_top[item], time,
                               apply_data_cleansing, alfa, defect_columns)

    return data_frame.drop(columns=list(defect_columns))
