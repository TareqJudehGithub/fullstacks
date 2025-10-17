// @ts-nocheck
import { StrictMode } from "react";
import { createRoot } from "react-dom/client";

import App from "./App.jsx";

// Styling
import "../node_modules/bootstrap/dist/css/bootstrap.css";

import "./style.css";

createRoot(document.getElementById("root")).render(
	<StrictMode>
		<App />
	</StrictMode>
);
