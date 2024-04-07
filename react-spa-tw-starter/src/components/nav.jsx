import {Link, useNavigate} from "react-router-dom";
import {useAuth} from "@/hooks/useAuth.jsx";
import {useCallback} from "react";

export default function Nav() {
	const { logout } = useAuth();
	const goTo = useNavigate();
	const tryLogout = useCallback(() => {
		logout();
		goTo("/login");
	}, [logout]);
	return <>
		<nav className="bg-gray-800">
			<div className="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
				<div className="relative flex h-16 items-center justify-between">
					<div className="flex flex-1 items-center justify-center sm:items-stretch sm:justify-start">
						<div className="flex flex-shrink-0 items-center">
							<img className="h-8 w-auto"
								 src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=500"
								 alt="Your Company"/>
						</div>
						<div className="hidden sm:ml-6 sm:block">
							<div className="flex space-x-4">
								{
								/** bg-gray-900 text-white rounded-md px-3 py-2 text-sm font-medium  **/
								}
								<Link to="/" className="nav-link"
								   aria-current="page">Dashboard</Link>
								<Link to="/about" href="#"
								   className="nav-link">About</Link>
								<button type="button" to="/logout" className="nav-link" onClick={tryLogout}>
									Logout
								</button>
							</div>
						</div>
					</div>
				</div>
			</div>

			<div className="sm:hidden" id="mobile-menu">
				<div className="space-y-1 px-2 pb-3 pt-2">
					<a href="#" className="bg-gray-900 text-white block rounded-md px-3 py-2 text-base font-medium"
					   aria-current="page">Dashboard</a>
					<a href="#"
					   className="text-gray-300 hover:bg-gray-700 hover:text-white block rounded-md px-3 py-2 text-base font-medium">Team</a>
					<a href="#"
					   className="text-gray-300 hover:bg-gray-700 hover:text-white block rounded-md px-3 py-2 text-base font-medium">Projects</a>
					<a href="#"
					   className="text-gray-300 hover:bg-gray-700 hover:text-white block rounded-md px-3 py-2 text-base font-medium">Calendar</a>
				</div>
			</div>
		</nav>
	</>
}