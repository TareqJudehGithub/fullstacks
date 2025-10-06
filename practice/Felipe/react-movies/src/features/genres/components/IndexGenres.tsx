import { NavLink, Outlet } from "react-router-dom";
export default function IndexGenres() {
	return (
		<>
			<h3>Genres</h3>
			<NavLink className="btn btn-primary" to="create">
				Create
			</NavLink>
			<NavLink className="nav-link" to="edit">
				Edit
			</NavLink>
			<Outlet />
		</>
	);
}
