(function () {
    "use strict";

    var treeviewMenu = $('.app-menu');

    // Toggle Sidebar
    $('[data-toggle="sidebar"]').click(function (event) {
        event.preventDefault();
        $('.app').toggleClass('sidenav-toggled');
    });

    // Activate sidebar treeview toggle
    $("[data-toggle='treeview']").click(function (event) {
        event.preventDefault();
        if (!$(this).parent().hasClass('is-expanded')) {
            treeviewMenu.find("[data-toggle='treeview']").parent().removeClass('is-expanded');
        }
        $(this).parent().toggleClass('is-expanded');
    });

    // Set initial active toggle
    $("[data-toggle='treeview.'].is-expanded").parent().toggleClass('is-expanded');

    //Activate bootstrip tooltips
    $("[data-toggle='tooltip']").tooltip();

})();

const steps = document.querySelectorAll('.progress_bar-step');
const steps_container = document.querySelector('.progress_bar-steps');
const steps_progress = document.querySelector('.progress_bar-progress');
const prev_btn = document.querySelector('.progress_bar-nav .prev');
const next_btn = document.querySelector('.progress_bar-nav .next');

function init() {
    const cur_step = steps_container.getAttribute('data-cur_step_index');
    if (!cur_step) {
        steps_container.setAttribute('data-cur_step_index', 0)
    }
    changeProgress(cur_step);
}
init();

steps.forEach((step, index) => {
    step.setAttribute('data-step', index);

    step.addEventListener('click', () => {
        const step_index = step.getAttribute('data-step')
        changeProgress(step_index)
    })
})

prev_btn.addEventListener('click', () => {
    if (!prev_btn.classList.contains('active')) {
        return;
    }

    const cur_step = steps_container.getAttribute('data-cur_step_index');
    changeProgress(+cur_step - 1)
})

next_btn.addEventListener('click', () => {
    if (!next_btn.classList.contains('active')) {
        return;
    }

    const cur_step = steps_container.getAttribute('data-cur_step_index');
    changeProgress(+cur_step + 1)
})

function changeProgress(targetStepIndex) {
    const step_length = steps.length;
    steps_container.setAttribute('data-cur_step_index', targetStepIndex)

    // add progress percentage
    steps_progress.style.width = `${targetStepIndex / (step_length - 1) * 100}%`

    // add before
    if (targetStepIndex > 0) {
        for (i = 0; i <= targetStepIndex; i++) {
            steps[i].classList.add('active')
        }
        prev_btn.classList.add('active')
    } else {
        prev_btn.classList.remove('active')
    }

    // remove after
    if (targetStepIndex < (step_length - 1)) {
        for (i = (+targetStepIndex + 1); i < step_length; i++) {
            steps[i].classList.remove('active')
        }

        next_btn.classList.add('active')
    } else {
        next_btn.classList.remove('active')
    }
}

function validate() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password-field").value;
    //Đặt 1 Admin ảo để đăng nhập quản trị
    //if (username == "admin" && password == "123456") {
    //    swal({
    //        title: "",
    //        text: "Xin chào HienCa",
    //        icon: "success",
    //        close: true,
    //        button: false,
    //    });
    //    window.location = "../doc/index.html";
    //    return true;

    //}
    //Nếu không nhập gì mà nhấn đăng nhập thì sẽ báo lỗi
    if (username == "" && password == "") {
        swal({
            title: "",
            text: "Bạn chưa điền đầy đủ thông tin đăng nhập...",
            icon: "error",
            close: true,
            button: "Thử lại",
        });
        $(document).ready(function () {
                $('form').submit(function (event) {
                    $.ajax({
                        method: $(this).attr('method'),
                        url: $(this).attr('action'),
                        data: $(this).serialize(),

                        /* ... other AJAX settings ... */
                    }).done(function (response) {
                        // Process the response here
                    });
                    event.preventDefault(); // <- avoid reloading
                });
            });
        return false;

    }
    //Nếu không nhập mật khẩu mà đúng tài khoản 
    if (username == "admin" && password == "") {
        swal({
            title: "",
            text: "Bạn chưa nhập mật khẩu...",
            icon: "warning",
            close: true,
            button: "Thử lại",
        });
        $(document).ready(function () {
            $('form').submit(function (event) {
                $.ajax({
                    method: $(this).attr('method'),
                    url: $(this).attr('action'),
                    data: $(this).serialize(),

                    /* ... other AJAX settings ... */
                }).done(function (response) {
                    // Process the response here
                });
                event.preventDefault(); // <- avoid reloading
            });
        });
        return false;
    }
    //Nếu không nhập tài khoản sẽ báo lỗi
    if (username == null || username == "") {
        swal({
            title: "",
            text: "Tài khoản đang để trống...",
            icon: "warning",
            close: true,
            button: "Thử lại",
        });
        $(document).ready(function () {
            $('form').submit(function (event) {
                $.ajax({
                    method: $(this).attr('method'),
                    url: $(this).attr('action'),
                    data: $(this).serialize(),

                    /* ... other AJAX settings ... */
                }).done(function (response) {
                    // Process the response here
                });
                event.preventDefault(); // <- avoid reloading
            });
        });
        return false;
    }
    //Nếu không nhập mật khẩu sẽ báo lỗi
    if (password == null || password == "") {
        swal({
            title: "",
            text: "Mật khẩu đang để trống...",
            icon: "warning",
            close: true,
            button: "Thử lại",
        });
        $(document).ready(function () {
            $('form').submit(function (event) {
                $.ajax({
                    method: $(this).attr('method'),
                    url: $(this).attr('action'),
                    data: $(this).serialize(),

                    /* ... other AJAX settings ... */
                }).done(function (response) {
                    // Process the response here
                });
                event.preventDefault(); // <- avoid reloading
            });
        });
        return false;
    }
    //Nếu trống toàn bộ thì báo lỗi
    //else {
    //    swal({
    //        title: "",
    //        text: "Sai thông tin đăng nhập hãy kiểm tra lại...",
    //        icon: "error",
    //        close: true,
    //        button: "Thử lại",
    //    });
    //    return true;
    //};
}

/*  PHẦN NỘI DUNG KHÔI PHỤC MẬT KHẨU   */

/* =========================================== */
/* =========================================== */
//  function validate() {
//      var email = document.getElementById("email").value;
//     if (email == null || email == "") {
//        swal("Bạn Chưa Nhập Email", "Vui Lòng Kiểm Tra", "warning");
//        return false;
//    }
//}
function RegexEmail(emailInputBox) {
    var emailStr = document.getElementById(emailInputBox).value;
    var emailRegexStr = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    var isvalid = emailRegexStr.test(emailStr);
    if (!isvalid) {
        swal({
            title: "",
            text: "Bạn vui lòng nhập đúng định dạng email...",
            icon: "error",
            close: true,
            button: "Thử lại",
        });

        emailInputBox.focus;
    } else {
        swal({
            title: "",
            text: "Chúng tôi vừa gửi cho bạn email hướng dẫn đặt lại mật khẩu vào địa chỉ cho bạn",
            icon: "success",
            close: true,
            button: "Đóng",
        });
        emailInputBox.focus;
        window.location = "#";

    }
}
