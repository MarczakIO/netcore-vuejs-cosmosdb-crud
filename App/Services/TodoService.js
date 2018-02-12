export default {
    getAll: () => {
        return fetch('/api/Todo/GetAll', {
            method: 'get',
            headers: {'Content-Type': 'application/json'}
        }).then(function (response) {
            return response.json();
        }).then(function (response) {
            return response;
        });
    },
    create: (item) => {
        var data = JSON.stringify(item);
        return fetch('/api/Todo/Create', {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: data
        }).then(function (response) {
            return response.json();
        }).then(function (response) {
            return response;
        });
    },
    update: (item, newValue) => {
        var updateItem = { ...item, name: newValue }
        var data = JSON.stringify(updateItem);
        return fetch('/api/Todo/Update', {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: data
        }).then(function (response) {
            return response.json();
        }).then(function (response) {
            return response;
        });
    },
    delete: (item) => {
        var data = JSON.stringify(item);
        return fetch('/api/Todo/Delete', {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: data
        }).then(function (response) {
            return response;
        });
    }
}