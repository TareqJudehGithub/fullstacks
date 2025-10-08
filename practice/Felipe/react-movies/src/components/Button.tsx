import type { JSX } from "react";

export default function Button(props: ButtonProps): JSX.Element {
	return (
		<button
			className="btn btn-primary"
			disabled={props.disabled ?? false} // Enabled by default
			onClick={props.onClick}
			// If type (button or submit) is present, use them as type, if not then
			// use "button"
			// using Nullish coalescing operator
			type={props.type ?? "button"}
			//type={props.type ? props.type : "button"}   Ternary with ? and :
		>
			{props.children}{" "}
		</button>
	);
}

interface ButtonProps {
	children: React.ReactNode;
	onClick?(): void;
	type?: "button" | "submit";
	disabled?: boolean;
}
