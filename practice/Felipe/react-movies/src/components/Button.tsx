import type { JSX } from "react";

export default function Button(props: ButtonProps): JSX.Element {
	return (
		<button className="btn btn-primary" onClick={props.onClick}>
			{props.children}{" "}
		</button>
	);
}

interface ButtonProps {
	children: React.ReactNode;
	onClick(): void;
}
