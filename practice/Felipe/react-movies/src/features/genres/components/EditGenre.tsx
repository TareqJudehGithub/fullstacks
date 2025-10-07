// React
import type { JSX } from "react";

// React Router
import { useParams } from "react-router-dom";

export default function EditGenre(): JSX.Element {
	const { id } = useParams();
	return <div>EditGenre: {id}</div>;
}
