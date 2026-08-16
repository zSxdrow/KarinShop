const userID = localStorage.getItem("userID");
const tbody = document.getElementById("ticketTable");

document.addEventListener("DOMContentLoaded", function () {
  getTickets();
  getDepartment()
  

  
 
});

function getStatusClass(status) {
  switch (status.toLowerCase()) {
    case "new":
      return "label label-success";
    case "open":
      return "label label-default";
    case "close":
      return "label label-danger";
    default:
      return "label label-default";
  }
}
$('.nice-select').each(function(){
    const select = $(this).prev('select'); // select اصلی قبل از div
    $(this).remove(); // حذف div پلاگین
    select.show();    // نمایش select اصلی
});

async function getTickets() {
  debugger;

  const url = `https://localhost:7097/api/tickets/user/${userID}`;

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

    const tickets = await response.json();
    console.log(tickets);
    tickets.forEach((ticket) => {
      const tr = document.createElement("tr");

      tr.innerHTML = `
    <td>
     
      <a href="#" class="user-link">${ticket.subject}</a>
    
    </td>
    <td>${new Date(ticket.createdAt).toLocaleDateString()}</td>
    <td class="text-center">
      <span class="${getStatusClass(ticket.status.title)}">${ticket.status.title}</span>
    </td>
    <td><a href="#">${ticket.department.name}</a></td>
    <td><a href="#">${ticket.priority.title}</a></td>
    <td style="width: 20%;">
      <a href="#" class="table-link"><i class="fas fa-search"></i></a>
      <a href="#" class="table-link"><i class="fas fa-edit"></i></a>
      <a href="#" class="table-link danger"><i class="fas fa-trash-alt"></i></a>
    </td>
  `;

      tbody.appendChild(tr);
    });
  } catch (error) {
    console.error("Error fetching item detail:", error);
    return null;
  }
}

async function getDepartment() {
  debugger;

  const url = `https://localhost:7097/api/departments`;

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

    const departments = await response.json();
    const optionDepartment =document.getElementById('departmentSelect')
    optionDepartment.style.display="flex"

    departments.forEach((department) => {
      optionDepartment.innerHTML += `<option value="${department.id}">${department.name}</option>`;
    });
  } catch (error) {
    console.error("Error fetching item detail:", error);
    return null;
  }
}
document.getElementById("openNew").addEventListener("click", function (e) {
    const newTickectTable =document.getElementById("newTicket")
    newTickectTable.style.opacity="100%"

    console.log("moo")
})
document.getElementById("btnAddTicket").addEventListener("click", function (e) {
    debugger
    let valueMassage = document.getElementById('Massage').value
    let valueSubject = document.getElementById('Subject').value
    let valuedepartmentSelect = Number(document.getElementById('departmentSelect').value)
    let valuePrionty = Number(document.getElementById('Prionty').value)
    let valuefile = document.getElementById('file').value

    console.log(typeof userID)
    console.log(valueSubject)
    console.log(typeof valuedepartmentSelect)
    console.log(typeof valuePrionty)
    console.log(valuefile)

    
    let Ticket = {
      priority: valuePrionty,
      fkUser: Number(userID),
      subject: valueSubject,
      fkDepartment: valuedepartmentSelect,
      message: valueMassage,
      attachment: valuefile,
    };

  
    fetch("https://localhost:7097/api/Tickets/create", {
      method: "POST",
      headers: {
        "Content-Type": "application/json", 
      },
      body: JSON.stringify(Ticket), 
    })
      .then((response) => response.text()) 
      .then((data) => {
        console.log("پاسخ سرور:", data);
        showToast("محصول با موفقیت اضافه شد ✅", "success");
        location.reload()
   
      })
      .catch((error) => console.error("خطا در ارسال:", error));

})
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