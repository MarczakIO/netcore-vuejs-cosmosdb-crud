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
    }
}