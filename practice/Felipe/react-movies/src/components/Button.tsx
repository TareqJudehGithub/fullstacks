export default function Button(props: ButtonProps): React.ReactNode {
	return <button className="btn btn-primary">{props.children} </button>;
}

interface ButtonProps {
	children: React.ReactNode;
}
