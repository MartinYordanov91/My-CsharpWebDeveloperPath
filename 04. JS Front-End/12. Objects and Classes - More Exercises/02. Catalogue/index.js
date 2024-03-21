function solve(input) {
  let products = input.reduce((acc, product) => {
    let [productName, productPrice] = product.split(" : ");
    let later = productName[0];

    if (!acc[later]) {
      acc[later] = [];
    }

    acc[later].push({ name: productName, price: productPrice });

    return acc;
  }, {});

  Object.keys(products)
    .sort()
    .forEach((later) => {
      console.log(later);
      products[later]
            .sort((a , b) => a.name.localeCompare(b.name))
            .forEach((item) => {
                console.log(`  ${Object.values(item)[0]}: ${Object.values(item)[1]}`)
            })
    });
}

solve([
  "Appricot : 20.4",
  "Fridge : 1500",
  "TV : 1499",
  "Deodorant : 10",
  "Boiler : 300",
  "Apple : 1.25",
  "Anti-Bug Spray : 15",
  "T-Shirt : 10",
]);

solve(["Omlet : 5.4", "Shirt : 15", "Cake : 59"]);
