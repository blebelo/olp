import type { Metadata } from "next";
import { AuthProvider } from "@/providers/auth-provider";
import { InstructorProvider } from "@/providers/instructorProvider";
import { CourseProvider } from "@/providers/course-provider";
import "./globals.css";


export const metadata: Metadata = {
  title: "DevAcademy - Launch your coding journey",
  description: "Master our tech stack and coding standards.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <AuthProvider>
      <InstructorProvider>
        
      <CourseProvider>
        <html lang="en">
          <body>
            {children}
          </body>
        </html>
      </InstructorProvider>
      </CourseProvider>
    </AuthProvider>
  );
}
