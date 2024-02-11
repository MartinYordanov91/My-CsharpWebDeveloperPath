function spiceCultivate(quantity) {
  let days = 0;
  let cultivate = 0;

  while (quantity >= 100) {
    let curentrecive = quantity - 26;
    quantity -= 10;
    days++;
    cultivate += curentrecive;
  }

  if(cultivate >= 26){
    cultivate -= 26;
  }

  console.log(days);
  console.log(cultivate);
}

spiceCultivate(111);
spiceCultivate(450);
