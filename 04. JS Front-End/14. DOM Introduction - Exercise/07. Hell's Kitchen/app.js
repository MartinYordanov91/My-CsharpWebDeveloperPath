function solve() {
  document.querySelector("#btnSend").addEventListener("click", onClick);
  

  function onClick() {
    const inputTextAreaElement = document.querySelector("textarea");
    const bestResuturantOutputElement = document.querySelector("#bestRestaurant p");
    const workersOutputElement = document.querySelector("#workers p");
    const arayElements = inputTextAreaElement.value
      .slice(1, -1)
      .match(/"(.*?)"/g)
      .map((e) => e.slice(1, -1));

    const readyOutput = arayElements.reduce((acc, current) => {
      const [objName, workersStr] = current.split(" - ");
      const workers = workersStr.split(", ").map((workerStr) => {
        const [name, salary] = workerStr.split(" ");
        return { name, salary: Number(salary) };
      });

      // Find existing company object, if it exists
      const existingCompany = acc.find((company) => company.name === objName);

      if (existingCompany) {
        // Update existing company's worker list and recalculate statistics
        existingCompany.workers.push(...workers);
        existingCompany.highestSalary = Math.max(
          existingCompany.highestSalary,
          ...workers.map((worker) => worker.salary)
        );
        const totalSalary = existingCompany.workers.reduce(
          (sum, worker) => sum + worker.salary,
          0
        );
        existingCompany.averageSalary =
          totalSalary / existingCompany.workers.length;
      } else {
        // Create a new company object
        const highestSalary = Math.max(
          ...workers.map((worker) => worker.salary)
        );
        const totalSalary = workers.reduce(
          (sum, worker) => sum + worker.salary,
          0
        );
        const averageSalary = totalSalary / workers.length;

        acc.push({
          name: objName,
          highestSalary,
          averageSalary,
          workers,
        });
      }

      return acc;
    }, []);

    readyOutput.sort((a, b) => b.averageSalary - a.averageSalary);

    readyOutput.forEach((company) => {
      company.workers.sort((a, b) => b.salary - a.salary);
    });

    const bestCompany = readyOutput[0];
    let arryOfWorkers = bestCompany.workers.reduce((acc, worker) => {
      acc.push(`Name: ${worker.name} With Salary: ${worker.salary}`);
      return acc;
    }, []);

    const firstLine = `Name: ${bestCompany.name} Average Salary: ${bestCompany.averageSalary.toFixed(2)} Best Salary: ${bestCompany.workers[0].salary.toFixed(2)}`;
    const secondLine = arryOfWorkers.join(" ")

    bestResuturantOutputElement.textContent = firstLine
    workersOutputElement.textContent = secondLine
  }
}
