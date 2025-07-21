"use client"
import withAuth from "@/hoc/WithAuth";
import InstructorNavbar from "@/components/instructorNavbar/InstructorHeader";


const Trainer =({
    children,
}: Readonly<{
    children: React.ReactNode;
}>)=> {
    return (
        <>
            <InstructorNavbar/>
            { children }
        </>
    );
}
export default withAuth(Trainer, { allowedRoles: ['Instructor'] })