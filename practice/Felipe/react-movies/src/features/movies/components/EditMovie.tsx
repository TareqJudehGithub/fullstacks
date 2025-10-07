import type { JSX } from "react";
import { useParams } from "react-router-dom";

export default function EditMovie(): JSX.Element {
	const { id } = useParams();

	return <p>Edit Movie: {id}</p>;
}
