import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.metrics import mean_absolute_error, mean_squared_error, r2_score

result = {
    'Method name': [],
    'Alpha': [],
    'Mean Absolute Error': [],
    'Mean Squared Error': [],
    'Root Mean Squared Error': [],
    'R2': []
}

models = {
    'R2': [],
    'Model': []
}


def Select_best_model():
    return models['Model'][models['R2'].index(max(models['R2']))], result['Alpha'][result['R2'].index(max(result['R2']))]


def Prepare_data(data, price):
    x_train, x_test, y_train, y_test = train_test_split(data, price, test_size=0.2, random_state=40)
    return x_train, x_test, y_train, y_test


def Regression(model, data, price, method_name, alpha):
    x_train, x_test, y_train, y_test = Prepare_data(data, price)
    model.fit(x_train, y_train)
    y_pred = model.predict(x_test)

    result['Method name'].append(method_name)
    result['Alpha'].append(alpha)
    result['Mean Absolute Error'].append(float('{:.3f}'.format(mean_absolute_error(y_test, y_pred))))
    result['Mean Squared Error'].append(float('{:.3f}'.format(mean_squared_error(y_test, y_pred))))
    result['Root Mean Squared Error'].append(float('{:.3f}'.format(np.sqrt(mean_squared_error(y_test, y_pred)))))
    result['R2'].append(float('{:.3f}'.format(r2_score(y_test, y_pred))))

    models['R2'].append(float('{:.3f}'.format(r2_score(y_test, y_pred))))
    models['Model'].append(model)
