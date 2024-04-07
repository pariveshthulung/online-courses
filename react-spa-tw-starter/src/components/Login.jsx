import {requiredValidation, simpleValidation} from "@/hooks/validation.js";
import {useState} from "react";
import {Link, useNavigate} from "react-router-dom";
import useFetch from "@/hooks/useFetch.js";
import {useAuth} from "@/hooks/useAuth.jsx";

export default function Login() {
	const [username, setUsername] = useState("");
	const [usernameError, setUsernameError] = useState("");

	const [password, setPassword] = useState("");
	const [passwordError, setPasswordError] = useState("");

	const goTo = useNavigate();
	const fetcher = useFetch();

	const { login } = useAuth();

	const trySubmit = () => {
		if(!simpleValidation({value: username, errorSetter: setUsernameError, validatorFn: requiredValidation})) return;
		if(!simpleValidation({value: password, errorSetter: setPasswordError, validatorFn: requiredValidation})) return;

		fetcher("/api/account/login", {
			method: "POST",
			body: JSON.stringify({
				Username: username,
				Password: password
			}),
			headers: {
				"content-type" : "application/json"
			}
		})
		.then((result) => {
			login(result);
			goTo("/");
		}).catch(e => {
			const message = typeof e === "string" ? e : "Error during login";
			alert(message)
			console.log("Error during login", e)
		})
	};

	return <>
		<div className="min-h-screen flex items-center justify-center w-full dark:bg-gray-950">
			<div className="bg-white dark:bg-gray-900 shadow-md rounded-lg px-8 py-6 max-w-md">
				<h1 className="text-2xl font-bold text-center mb-4 dark:text-gray-200">Sign up!</h1>

				<div className="mb-4">
					<label htmlFor="username">
						Username
					</label>
					<input type="text" value={username} onChange={(e) => setUsername(e.target.value)}
						className="form-control"
					/>
					<div className="text-danger">{usernameError}</div>
				</div>
				<div className="mb-4">
					<label htmlFor="password">
						Password
					</label>
					<input type="password" value={password} onChange={(e) => setPassword(e.target.value)}
						className="form-control"
					/>
					<div className="text-danger">{passwordError}</div>
				</div>

				<button className="btn" onClick={trySubmit}>
					Login
				</button>
				<hr/>
				<div className="pt-2 p-1 mt-4 text-center border-t-2 border-solid">
					Don't have an account? &nbsp;
					<Link to="/register" className="btn btn-secondary">
						Sign Up!
					</Link>
				</div>
			</div>
		</div>
	</>
}