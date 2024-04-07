export function simpleValidation({
	value, errorSetter, validatorFn
}) {
	const error = validatorFn(value);
	if(error !== null) {
		errorSetter(error);
		return false;
	}
	return true;
}

export function requiredValidation(value, message = "Value is required") {
	if(!value || value.trim() === "") return message;
	return null;
}