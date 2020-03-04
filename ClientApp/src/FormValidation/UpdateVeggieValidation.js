import validator from "validator";

// Default Export: UpdateVeggieValidation
// Purpose: Validate Update veggie params on client side
// Name and price cannot be empty
// Name cannot contain numbers or symbols
// Name should be alphabetical but spaces are ok
// Price should be greater than zero
export default function UpdateVeggieValidation(name, price) {
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
  // here I am converting potential price as number to a string
  if (validator.isDecimal(`${price}`) === false) {
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
