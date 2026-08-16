let accept = document.getElementById("f-option2").checked;
let nameUser = document.getElementById("userName").value;
let email = document.getElementById("email").value;
let password = document.getElementById("password").value;
let conPassword = document.getElementById("confirmPassword").value;




document.getElementById("submitForm").addEventListener("click", function (e) {
  debugger;

  // if (document.getElementById("password").value === document.getElementById("confirmPassword").value && accept) {
    let userinfo = {
      userName: document.getElementById("userName").value,
      email: document.getElementById("email").value,
      password: document.getElementById("password").value,
    };

    fetch("https://localhost:7097/api/user/post", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(userinfo),
    })
      .then((response) => response.text())
      .then((data) => {
        console.log("پاسخ سرور:", data);
        showToast("محصول با موفقیت اضافه شد ✅", "success");
        window.location.href = "login.html";
      })
      .catch((error) => console.error("خطا در ارسال:", error));

  // } else {
  //   showToast(" ❌ رمز های واردشده یکی نیستند  ", "danger");
  // }
});

///
function showToast(message, type = "success") {
  const toast = document.createElement("div");

  const colors = {
    success: "#28a745",
    danger: "#dc3545",
    warning: "#ffc107",
    info: "#17a2b8",
  };

  toast.textContent = message;
  toast.style.position = "fixed";
  toast.style.bottom = "20px"; // 👈 پایین صفحه
  toast.style.right = "20px"; // 👈 سمت راست
  toast.style.background = colors[type];
  toast.style.color = "#fff";
  toast.style.padding = "12px 18px";
  toast.style.borderRadius = "6px";
  toast.style.zIndex = "9999";
  toast.style.boxShadow = "0 4px 10px rgba(0,0,0,.2)";
  toast.style.fontSize = "14px";

  document.body.appendChild(toast);

  setTimeout(() => {
    toast.style.opacity = "0";
    setTimeout(() => toast.remove(), 500);
  }, 3000);
}
