import {useAuth} from "@/hooks/useAuth.jsx";

export default function useFetch() {
	const user = useAuth();
	const headers = {};
	const baseUrl = import.meta.env.VITE_SERVER_API_URL;
	if(user != null) {
		headers['Authorization'] = "Bearer " + user.token;
	}
	return (url,options) => {
		const finalUrl = url.startsWith("/") ? baseUrl + url : url
		let finalHeaders = {
			...headers
		};
		if(typeof options.headers !== "undefined") {
			finalHeaders = {
				...headers, ...options.headers
			};
		}
		return fetch(finalUrl, {
			...options,
			headers: finalHeaders
		}).then(async res => {
			const data = await res.json();
			if (!res.ok) {
				throw data;
			}
			return data;
		});
	};
}