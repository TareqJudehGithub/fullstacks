import type { JSX } from "react";
import { NavLink, Outlet } from "react-router-dom";

export default function IndexTheaters(): JSX.Element {
	return (
		<>
			<NavLink className="btn btn-primary" to="create">
				Create Theater
			</NavLink>
			<NavLink className="nav-link" to="edit">
				Edit Theater
			</NavLink>
			<Outlet />
		</>
	);
}
