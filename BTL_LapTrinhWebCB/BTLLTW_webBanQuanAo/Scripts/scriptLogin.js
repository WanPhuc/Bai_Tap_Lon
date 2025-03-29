
function clickLogin(event) {
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    var notification = document.getElementById('notification');
    var form = document.getElementById('form');



    if (username == "" || password == "") {
        notification.innerHTML = "Thiếu thông tin đăng nhập !"
        notification.classList.remove('hidden');
        event.preventDefault();
        return;
    }
}