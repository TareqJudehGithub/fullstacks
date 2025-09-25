export default function (props: ContentProjection2) {
	return (
		<>
			<header>{props.header}</header>
			<main>{props.main}</main>
			<footer>{props.footer}</footer>
		</>
	);
}

interface ContentProjection2 {
	header: React.ReactNode;
	main: React.ReactNode;
	footer: React.ReactNode;
}
