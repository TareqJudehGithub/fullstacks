// React
import type { JSX } from "react";
// React-Router-DOM
import { useNavigate } from "react-router-dom";

// Components
import Button from "../../../components/Button";

export default function CreateGenre(): JSX.Element {
	const navigate = useNavigate();
	function handleClick() {
		return navigate("/genres");
	}
	return (
		<>
			<h4>Create Genre</h4>

			<Button onClick={handleClick}>Send</Button>
		</>
	);
}
