export default function DynamicContent(props: DynamicContentProps) {
	return <div>{props.displayContent ? <p>Display message</p> : <p></p>}</div>;
}

interface DynamicContentProps {
	displayContent: boolean;
}
