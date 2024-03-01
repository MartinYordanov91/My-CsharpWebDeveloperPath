function orderMachine(typeOfItem, quantity) {
  const items = {
    coffee: 1.5,
    water: 1,
    coke: 1.4,
    snacks: 2,
  };

  console.log((items[typeOfItem]*quantity).toFixed(2))
}

orderMachine("water", 5)
orderMachine("coffee", 2)
orderMachine("coke", 2)