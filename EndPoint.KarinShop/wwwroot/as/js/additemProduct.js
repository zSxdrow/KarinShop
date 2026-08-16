let products = [];
// /// اضافه کردن محصول
document
  .getElementById("addProductForm").addEventListener("submit", function (e) {
    e.preventDefault();

    // گرفتن مقادیر فرم
    let nameProduct = document.getElementById("nameProduct").value;
    let price = document.getElementById("price").value;
    let category = document.getElementById("category").value;
    let description = document.getElementById("discription").value;

    // ساخت شیء محصول
    let product = {
      name: nameProduct,
      price: price,
      category: category,
      description: description,
    };

    products.push(product);
    console.log(products);
    fetch("https://localhost:7097/api/Add-Item", {
      method: "POST",
      headers: {
        "Content-Type": "application/json", // فرستادن JSON
      },
      body: JSON.stringify(product), // فقط محصول جدید ارسال می‌شود
    })
      .then((response) => response.text()) // یا response.json() اگر JSON برگرده
      .then((data) => {
        console.log("پاسخ سرور:", data);
        showToast("محصول با موفقیت اضافه شد ✅", "success");
   
      })
      .catch((error) => console.error("خطا در ارسال:", error));
          //  showToast("محصول نمیتواند اضافه شود  ✅", "danger");
    // پاک کردن فرم
    e.target.reset();
  });

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

//////
