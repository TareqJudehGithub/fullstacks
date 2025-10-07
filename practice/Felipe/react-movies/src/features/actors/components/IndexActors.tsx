import type { JSX } from "react";
import { NavLink, Outlet } from "react-router-dom";

export default function IndexActors(): JSX.Element {
	return (
		<>
			<NavLink className="btn btn-primary" to="create">
				Create Actor
			</NavLink>
			<NavLink className="nav-link" to="edit/1">
				Edit Actor
			</NavLink>
			<Outlet />
		</>
	);
}
