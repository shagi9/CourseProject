export const firstAndLastNameRegValidator = (rule, value) => {
  if (value == null) { return Promise.resolve(); }
  const reg = new RegExp("^[a-zA-Z]+$");
  if (reg.test(value)) {
    return Promise.resolve();
    }
    return Promise.reject("Can only contain letters");
  };

export const userNameRexValidator = (rule, value) => {
  if (value == null) return Promise.resolve();
    const reg = new RegExp("^[a-zA-Z0-9]+$");
    if (reg.test(value)) {
    	return Promise.resolve();
    }
    return Promise.reject("Only number and letters are required.");
}

export const dateOfBirthValidator = (rule, value) => {
  if (value == null) return Promise.resolve();
    const now = new Date();
    const userDate = new Date(value);
    console.log(userDate);
    if (userDate < now) {
    	return Promise.resolve();
    }
    return Promise.reject("Data is invalid");
} 
