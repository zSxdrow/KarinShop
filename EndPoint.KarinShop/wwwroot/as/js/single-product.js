const params = new URLSearchParams(window.location.search);
console.log(params);
let idDetailPro = params.get("ID");
console.log(idDetailPro);

getItemDetail(idDetailPro);

async function getItemDetail(id) {
  const url = `https://localhost:7097/api/item-detail/${id}`;

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

    const data = await response.json();
    console.log(data);
    console.log(data.product);

    const containerProduct = document.getElementById("infoProduct");
    if (!containerProduct) return;
    containerProduct.innerHTML = "";
    containerProduct.innerHTML=`<div class="s_product_text">
						<h3>${data.product.name}</h3>
						<h2> ${Number(data.product.price).toLocaleString()} تومان</h2>
						<ul class="list">
							<li><a class="active" href="#"><span>Category</span> : ${data.product.category.name}</a></li>
							<li><a href="#"><span>Availibility</span> : In Stock</a></li>
						</ul>
						<p>${data.product.description}</p>
						<div class="product_count">
              <label for="qty">Quantity:</label>
              <button onclick="var result = document.getElementById('sst'); var sst = result.value; if( !isNaN( sst )) result.value++;return false;"
							 class="increase items-count" type="button"><i class="ti-angle-left"></i></button>
							<input type="text" name="qty" id="sst" size="2" maxlength="12" value="1" title="Quantity:" class="input-text qty">
							<button onclick="var result = document.getElementById('sst'); var sst = result.value; if( !isNaN( sst ) &amp;&amp; sst > 0 ) result.value--;return false;"
               class="reduced items-count" type="button"><i class="ti-angle-right"></i></button>
							<a class="button primary-btn" href="#">Add to Cart</a>               
						</div>
						<div class="card_area d-flex align-items-center">
							<a class="icon_btn" href="#"><i class="lnr lnr lnr-diamond"></i></a>
							<a class="icon_btn" href="#"><i class="lnr lnr lnr-heart"></i></a>
						</div>
					</div>`


    return data;
  } catch (error) {
    console.error("Error fetching item detail:", error);
    return null;
  }
}
