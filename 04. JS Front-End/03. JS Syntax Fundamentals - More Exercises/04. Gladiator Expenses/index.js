function gladiatorsCosting(
  loses,
  helmedPrice,
  swordPrice,
  shieldPrice,
  armorPrice
) {
  let costing = 0;
  costing += Math.floor(loses / 2) * helmedPrice;
  costing += Math.floor(loses / 3) * swordPrice;
  costing += Math.floor(loses / 6) * shieldPrice;
  costing += Math.floor(loses / 12) * armorPrice;
  console.log(`Gladiator expenses: ${costing.toFixed(2)} aureus`);
}

gladiatorsCosting(7, 2, 3, 4, 5);
gladiatorsCosting(23, 12.5, 21.5, 40, 200);
