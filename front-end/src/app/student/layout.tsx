"use client"
import withAuth from "@/hoc/WithAuth";
import StudentNavbar from "@/components/student-nabvar/page";
import { StudentProfileProvider } from "@/providers/studentProvider";

const Trainer = ({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) => {
    return (
        <StudentProfileProvider>
            <StudentNavbar />
            {children}
        </StudentProfileProvider>
    );
}
export default withAuth(Trainer, { allowedRoles: ['Student'] })