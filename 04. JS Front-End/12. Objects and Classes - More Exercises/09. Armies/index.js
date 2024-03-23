function solve(input) {

    function updateArmyCount(kingdoms, armyName, addCount) {

        for (const king in kingdoms) {

            if (kingdoms.hasOwnProperty(king)) {

                const armies = kingdoms[king];

                for (let i = 0; i < armies.length; i++) {

                    const army = armies[i];

                    if (army.name === armyName) {

                        army.count += addCount;
                        return true; 
                    }
                }
            }
        }
        return false; 
    }

    function printArmies(armies) {
        armies.sort((a, b) => b.count - a.count).forEach((army) => {
          console.log(`>>> ${army.name} - ${army.count}`);
        });
    }

    let leaderList = input.reduce((acc, curent) => {

    if (curent.includes("arrives")) {

      let newLeader = curent.split(" arrives")[0];
      acc[newLeader] = [];

    } else if (curent.includes(` defeated`)) {

      let defeatedLeader = curent.split(" defeated")[0];
      delete acc[defeatedLeader];

    } else if (curent.includes(`:`)) {
        
      let [leader, armyInfo] = curent.split(": ");
      let [armyName, armyCount] = armyInfo.split(", ");

      if (acc[leader] !== undefined) {
        acc[leader].push({ name: armyName, count: Number(armyCount)});
      }

    } else if(curent.includes("+")){

        let [armyName , addCount] = curent.split(" + ")
        updateArmyCount(acc , armyName , Number(addCount))
    }

    return acc;
  }, {});

  
    const sortedLeaders = Object.entries(leaderList).sort(([_, armies1], [__, armies2]) => {

        const totalArmyCount1 = armies1.reduce((total, army) => total + army.count, 0);
     const totalArmyCount2 = armies2.reduce((total, army) => total + army.count, 0);
        return totalArmyCount2 - totalArmyCount1;

    });

    sortedLeaders.forEach(([leader, armies]) => {
        const totalArmyCount = armies.reduce((sum, army) => sum + army.count, 0);
        console.log(`${leader}: ${totalArmyCount}`);
        printArmies(armies);
    });
}

solve([
  "Rick Burr arrives",
  "Fergus: Wexamp, 30245",
  "Rick Burr: Juard, 50000",
  "Findlay arrives",
  "Findlay: Britox, 34540",
  "Wexamp + 6000",
  "Juard + 1350",
  "Britox + 4500",
  "Porter arrives",
  "Porter: Legion, 55000",
  "Legion + 302",
  "Rick Burr defeated",
  "Porter: Retix, 3205",
]);

solve([
  'Rick Burr arrives', 
  'Findlay arrives',
  'Rick Burr: Juard, 1500',
  'Wexamp arrives',
  'Findlay: Wexamp, 34540',
  'Wexamp + 340',
  'Wexamp: Britox, 1155',
  'Wexamp: Juard, 43423',
]);