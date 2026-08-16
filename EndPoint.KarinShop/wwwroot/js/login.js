let nameUser = document.getElementById("userName").value;
let pass = document.getElementById("password").value;
let users = [];

document.addEventListener("DOMContentLoaded", async function () {
  await getUser();
});

async function getUser() {
  debugger;

  const url = `https://localhost:7097/api/user/get`;

  try {
    const response = await fetch(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const categories = await response.json(); // آرایه دسته‌ها
    console.log(categories);
    users = categories;
  } catch (error) {
    console.error("Error fetching item detail:", error);
    return null;
  }
}
document.getElementById("login").addEventListener("click", function (e) {
  debugger;
  const username = document.getElementById("userName").value.trim();
  const password = document.getElementById("password").value.trim();

  const user = users.find(
    (u) => u.userName === username 
  );

  if (user) {
    alert("✅ لاگین موفق");
    window.open("http://127.0.0.1:5501/index.html")

  } else {
    alert("❌ ID کاربری یا رمز عبور اشتباه است");
  }
  //    console.log( document.getElementById("userName").value)
  //   console.log(document.getElementById("password").value)
});
// && u.password === password
function login() {
  debugger;
  const username = document.getElementById("userName").value.trim();
  const password = document.getElementById("password").value.trim();

  const user = users.find(
    (u) => u.username === username && u.password === password
  );

  if (user) {
    alert("✅ لاگین موفق");
  } else {
    alert("❌ ID کاربری یا رمز عبور اشتباه است");
  }
}
