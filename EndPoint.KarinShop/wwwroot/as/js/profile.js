let user_name = document.getElementById('user_name')
let email = document.getElementById('email')
let password = document.getElementById('password')
const userID = localStorage.getItem("userID");



document.addEventListener("DOMContentLoaded",  function () {
  getInfomationUser()
});

async function getInfomationUser() {
  debugger;

  const url = `https://localhost:7097/api/profile/${userID}`;

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

    const information = await response.json();
    console.log(information);
    user_name.value =information.userName
    email.value =information.email
    password.value =information.password

  } catch (error) {
    console.error("Error fetching item detail:", error);
    return null;
  }
}
