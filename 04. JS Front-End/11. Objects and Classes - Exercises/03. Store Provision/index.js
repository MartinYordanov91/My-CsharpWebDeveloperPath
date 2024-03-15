function solve(curentStock, orderedStock) {
  curentStock.push(...orderedStock);

  let allStock = curentStock.reduce((acc, curent, i) => {
    if (i % 2 === 0) {
      if (!acc[curent]) {
        acc[curent] = 0;
      }

      acc[curent] += Number(curentStock[i + 1]);
    }
    return acc;
  }, {});

  for (const [key, value] of Object.entries(allStock)) {
    console.log(`${key} -> ${value}`);
  }
}

solve(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);

solve(
  ["Salt", "2", "Fanta", "4", "Apple", "14", "Water", "4", "Juice", "5"],
  ["Sugar", "44", "Oil", "12", "Apple", "7", "Tomatoes", "7", "Bananas", "30"]
);
