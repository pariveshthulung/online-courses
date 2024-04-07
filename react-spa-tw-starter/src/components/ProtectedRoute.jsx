import {useAuth} from "@/hooks/useAuth.jsx";
import {Navigate} from "react-router-dom";

export const ProtectedRoute = ({ children }) => {
	const { user } = useAuth();
	if (!user) {
		// user is not authenticated
		return <Navigate to="/login" />;
	}
	return children;
};