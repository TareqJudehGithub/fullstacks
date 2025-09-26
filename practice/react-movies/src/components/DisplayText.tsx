import React from "react";

// You destruct the props, but in our example are we are using props keyword.
export default function DisplayText(props: DisplayTextProps) {
	return <div>{props.message}</div>;
}

interface DisplayTextProps {
	message: string;
}
