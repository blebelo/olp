"use client"
import withAuth from "@/hoc/WithAuth";


const Trainer =({
    children,
}: Readonly<{
    children: React.ReactNode;
}>)=> {
    return (
        <>
            { children }
        </>
    );
}
export default withAuth(Trainer, { allowedRoles: ['Instructor'] })