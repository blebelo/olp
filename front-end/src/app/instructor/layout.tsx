"use client"

import withAuth from "@/hoc/WithAuth";
import InstructorNavbar from "@/components/instructorNavbar/InstructorHeader";
import { InstructorProvider } from "@/providers/instructorProvider";


const Trainer =({
    children,
}: Readonly<{
    children: React.ReactNode;
}>)=> {
    return (
        <InstructorProvider>
            <InstructorNavbar/>
            { children }
        </InstructorProvider>
    );
}
export default withAuth(Trainer, { allowedRoles: ['Instructor'] })