import {Link, Outlet} from "react-router-dom";
import React from "react";
import Nav from "@/components/nav.jsx";

export function Layout() {
	return <>
		<Nav/>
		<div className="container mt-4">
			<Outlet/>
		</div>
	</>
}