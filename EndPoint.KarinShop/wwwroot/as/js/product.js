document.addEventListener("DOMContentLoaded", async function () {
  // برای سرچ با input
  const searchInput = document.querySelector(".filter-bar-search input");
  if (!searchInput) return;

  let debounceTimeout;
  searchInput.addEventListener("input", () => {
    clearTimeout(debounceTimeout);
    debounceTimeout = setTimeout(() => {
      getProductInfo(searchInput.value);
    }, 300); // صبر 300ms بعد از تایپ
  });

  // نمایش اولیه همه محصولات
  getProductInfo();
  await getCategory();
});

function getProductInfo(query = "") {
  const containerProduct = document.getElementById("container_products");
  if (!containerProduct) return;

  containerProduct.innerHTML = "";

  fetch("https://localhost:7097/api/Show-Item")
    .then((response) => {
      if (!response.ok) {
        throw new Error("HTTP Error: " + response.status);
      }
      return response.json();
    })
    .then((products) => {
      console.log(products);
      const q = query.trim().toLowerCase();

      const filteredProducts = products.filter(
        (product) =>
          product.name.toLowerCase().includes(q) ||
          product.category.toLowerCase().includes(q)
      );

      if (!filteredProducts.length) {
        containerProduct.innerHTML = `
          <div class="col-12 text-center">
            <p>هیچ محصولی پیدا نشد</p>
          </div>`;
        return;
      }

      filteredProducts.forEach((product) => {
        const col = document.createElement("div");
        col.className = "col-md-6 col-lg-4";

        col.innerHTML = `
          <div class="card text-center card-product">
            <div class="card-product__img">
              <img
                class="card-img"
                src="~/${product.image || "img/product/product1.png"}"
                alt="${product.name}"
              />
              <ul class="card-product__imgOverlay">
                <li>
                  <button title="افزودن به سبد">
                    <a href="~/single-product.html?ID=${product.id}" title="افزودن به سبد">
                      <i class="ti-shopping-cart"></i>
                    </a>
                  </button>
                </li>
              </ul>
            </div>

            <div class="card-body">
              <p>${product.category}</p>
              <h4 class="card-product__title">
                <a href="#">${product.name}</a>
              </h4>
              <p class="card-product__price">
                ${Number(product.price).toLocaleString()} تومان
              </p>
            </div>
          </div>
        `;

        containerProduct.appendChild(col);
      });
    })
    .catch((error) => {
      console.error(error);
      containerProduct.innerHTML = `
        <div class="col-12 text-center">
          <p>خطا در دریافت محصولات</p>
        </div>`;
    });
}

async function getCategory() {
  debugger; // توقف دیباگ
  const url = `https://localhost:7097/api/category/category-list`;

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
    renderCategories(categories);
    return categories;
  } catch (error) {
    console.error("Error fetching item detail:", error);
    return null;
  }
}

function renderCategories(categories) {
  debugger; // توقف دیباگ
  const ul = document.getElementById("category-item");
  ul.innerHTML = ""; // پاک کردن محتوای قبلی

  categories.forEach((category) => {
    const id = category.trim().toLowerCase();

    const li = document.createElement("li");
    li.className = "filter-list";
{/* <input class="pixel-radio" type="radio" id="${id}" name="brand" /> */}
    li.innerHTML = `
     
      <label for="${id}">${category}</label>
    `;

    ul.appendChild(li);
  });
}
