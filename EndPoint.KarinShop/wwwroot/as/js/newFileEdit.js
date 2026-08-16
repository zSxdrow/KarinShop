// document.addEventListener("DOMContentLoaded", () => {
//   getProductInfo();
//   getCategory();
// });

// let products = [];
// let usersinfo = [];

// // اطلاعات محصولات
// function getProductInfo() {
//   fetch("https://dummyjson.com/products")
//     .then((response) => {
//       if (!response.ok) {
//         throw new Error("Network response was not ok " + response.statusText);
//       }
//       return response.json();
//     })
//     .then((data) => {
//       console.log("داده‌ها از بک‌اند:", data);

//       const containerProduct = document.getElementById("container_products");
//       containerProduct.innerHTML = "";

//       // استفاده از data.products به جای data
//       data.products.forEach((product) => {
//         const col = document.createElement("div");
//         col.className = "col-md-6 col-lg-4";

//         col.innerHTML = `
//         <div class="card text-center card-product">
//           <div class="card-product__img">
//             <img class="card-img" src="~/https://asmaneshab.com/wp-content/uploads/2020/06/%D8%A2%D9%85%D9%88%D8%B2%D8%B4-%D8%B9%DA%A9%D8%A7%D8%B3%DB%8C-%D8%A7%D8%B2-%D9%84%D8%A8%D8%A7%D8%B3-%D8%A8%D8%B1%D8%A7%DB%8C-%D8%B3%D8%A7%DB%8C%D8%AA.jpg" alt="${
//               product.title
//             }">
//             <ul class="card-product__imgOverlay">
//               <li><button><i class="ti-search"></i></button></li>
//               <li><button><i class="ti-shopping-cart"></i></button></li>
//               <li><button><i class="ti-heart"></i></button></li>
//             </ul>
//           </div>
//           <div class="card-body">
//             <p>${product.category}</p>
//             <h4 class="card-product__title">
//               <a href="#">${product.title}</a>
//             </h4>
//             <p class="card-product__price">$${product.price.toFixed(2)}</p>
//           </div>
//         </div>
//       `;

//         containerProduct.appendChild(col);
//       });
//     })
//     .catch((error) => {
//       console.error("خطا در دریافت داده‌ها:", error);
//     });
// }

// // دسته بندی
// function getCategory() {
//   fetch("https://dummyjson.com/products/categories")
//     .then((response) => {
//       if (!response.ok) {
//         throw new Error("Network response was not ok " + response.statusText);
//       }
//       return response.json();
//     })
//     .then((data) => {
//       console.log("داده‌ها از بک‌اند:", data);
//       const ul = document.getElementById("category-item");
//       ul.innerHTML = ""; // خالی کردن UL قبل از اضافه کردن آیتم‌ها

//       data.forEach((brand) => {
//         const li = document.createElement("li");
//         li.classList.add("filter-list");

//         li.innerHTML = `
//           <input class="pixel-radio" type="radio" id="${brand.name}" name="brand">
//           <label for="${brand.name}">${brand.name}</label>
//         `;

//         ul.appendChild(li);
//       });
//     })
//     .catch((error) => {
//       console.error("خطا در دریافت داده‌ها:", error);
//     });
// }

// /// اضافه کردن محصول
// document
//   .getElementById("addProductForm")
//   .addEventListener("submit", function (e) {
//     e.preventDefault();

//     // گرفتن مقادیر فرم
//     let nameProduct = document.getElementById("nameProduct").value;
//     let price = document.getElementById("price").value;
//     let category = document.getElementById("category").value;
//     let description = document.getElementById("discription").value;

//     // ساخت شیء محصول
//     let product = {
//       name: nameProduct,
//       price: price,
//       category: category,
//       description: description,
//     };

//     products.push(product);

//     fetch("http://localhost:5013/api/additem", {
//       method: "POST",
//       headers: {
//         "Content-Type": "application/json", // فرستادن JSON
//       },
//       body: JSON.stringify(product), // فقط محصول جدید ارسال می‌شود
//     })
//       .then((response) => response.text()) // یا response.json() اگر JSON برگرده
//       .then((data) => {
//         console.log("پاسخ سرور:", data);
//       })
//       .catch((error) => console.error("خطا در ارسال:", error));

//     // پاک کردن فرم
//     e.target.reset();
//   });

// // اضافه کردن اطلاعات برای تماس با ما
// document.getElementById("sub").addEventListener("submit", function (e) {
//   e.preventDefault();

//   let name = document.getElementById("name").value;
//   let email = document.getElementById("email").value;
//   let phoneNumber = document.getElementById("phoneNumber").value;
//   let massage = document.getElementById("message").value;

//   let userinfo = {
//     name: name,
//     price: email,
//     category: phoneNumber,
//     description: massage,
//   };

//   usersinfo.push(userinfo);
//   fetch("http://localhost:5013/api/contactus", {
//     method: "POST",
//     headers: {
//       "Content-Type": "application/json", // فرستادن JSON
//     },
//     body: JSON.stringify(userinfo),
//   })
//     .then((response) => response.text()) // یا response.json() اگر JSON برگرده
//     .then((data) => {
//       console.log("پاسخ سرور:", data);
//     })
//     .catch((error) => console.error("خطا در ارسال:", error));

//   // پاک کردن فرم
//   e.target.reset();
// });

// const searchBtn = document.getElementById('searchBtn');
// const searchBox = document.getElementById('searchBox');
// const searchInput = document.getElementById('searchInput');

// searchBtn.addEventListener('click', () => {
//   // نمایش یا مخفی کردن input
//   if (searchBox.style.display === 'none') {
//     searchBox.style.display = 'inline-block';
//     searchInput.focus(); // فوکوس روی input
//   } else {
//     searchBox.style.display = 'none';
//   }
// });

// // می‌تونی اینجا جستجو رو هم مدیریت کنی
// searchInput.addEventListener('keypress', (e) => {
//   if (e.key === 'Enter') {
//     alert('جستجو برای: ' + searchInput.value);
//     // یا اینجا می‌تونی تابع جستجوی واقعی رو صدا بزنی// تابع سرچ کردن را بنویس و اینجا صدا بزن
//   }
// });
