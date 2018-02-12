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
    }
}