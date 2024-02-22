function miningGoldForBitcoin(array) {
  const priceGold = 67.51;
  const priceBitcoin = 11949.16;
  let money = 0;
  let firstBitcoinDay = 0;
  let countOfBitcoin = 0;

  for (let index = 0; index < array.length; index++) {
    let urnedGoldForCurentDay = array[index];

    if ((index + 1) % 3 === 0) {
      urnedGoldForCurentDay *= 0.7;
    }
    money += urnedGoldForCurentDay * priceGold;

    while (money >= priceBitcoin) {
      countOfBitcoin === 0 ? (firstBitcoinDay = index + 1) : "";
      countOfBitcoin++;
      money -= priceBitcoin;
    }
  }
  console.log(`Bought bitcoins: ${countOfBitcoin}`);
  countOfBitcoin > 0 ? console.log(`Day of the first purchased bitcoin: ${firstBitcoinDay}`) : "";
  console.log(`Left money: ${money.toFixed(2)} lv.`)
}

miningGoldForBitcoin([100, 200, 300])
miningGoldForBitcoin([50, 100])
miningGoldForBitcoin([3124.15, 504.212, 2511.124])