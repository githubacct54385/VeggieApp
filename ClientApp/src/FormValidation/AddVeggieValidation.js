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

  // name must be alphabetical
  if (validator.isAlpha(name) === false) {
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
