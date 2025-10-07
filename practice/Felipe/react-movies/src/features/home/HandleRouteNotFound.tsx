import { useEffect, type JSX } from "react";
import { Navigate, useLocation } from "react-router-dom";
export default function HandleRouteNotFound(): JSX.Element {
	const location = useLocation();

	useEffect(() => {
		console.log(`Route not found: ${location.pathname}`);
	}, [location]);

	return <h4>Route not found: {location.pathname}</h4>;

	// In case the user entered a wrong url, return to the homepage route"/"
	return <Navigate to="/" />;
}
