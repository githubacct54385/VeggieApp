import validator from "validator";

export default function AddVeggieValidation(name, price) {
  // name cannot be empty
  if (name === "") {
    return {
      hasError: true,
      err: "Veggie name cannot be empty",
      field: "name"
    };
  }

  // todo this isnt working...
  const symbolsPattern = /[[./!@#$%^&*/(\)\[\]+=<>?;:\"\'|~`]]/g;
  if (symbolsPattern.test(name) === true) {
    return {
      hasError: true,
      err: "Veggie name cannot contain symbols.",
      field: "name"
    };
  }

  // name cannot be numeric
  const numericPattern = /[0-9]/g;
  if (numericPattern.test(name) === true) {
    return {
      hasError: true,
      err: "Veggie name cannot be numeric.",
      field: "name"
    };
  }

  const correctNamePattern = /([\s]*[A-Za-z]*[\s]*[A-Za-z]*)*/g;
  // name must be alphabetical, spaces are ok.
  if (correctNamePattern.test(name) === false) {
    return {
      hasError: true,
      err: "Veggie name must be alphabetical",
      field: "name"
    };
  }

  // price must be a number
  if (validator.isDecimal(price) === false) {
    return {
      hasError: true,
      err: "Veggie price is NAN.",
      field: "price"
    };
  }
  // price must be a greater than zero
  if (price <= 0) {
    return {
      hasError: true,
      err: "Veggie price cannot be less than or equal to zero",
      field: "price"
    };
  }
  return { hasError: false, err: "", field: "" };
}
