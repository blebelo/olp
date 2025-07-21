"use client"
import withAuth from "@/hoc/WithAuth";
import StudentNavbar from "@/components/student-nabvar/page";

const Trainer = ({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) => {
    return (
        <>
            <StudentNavbar />
            {children}
        </>
    );
}
export default withAuth(Trainer, { allowedRoles: ['Student'] })