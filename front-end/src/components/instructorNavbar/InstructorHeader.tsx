import React, { useState } from "react";
import type { MenuInfo } from "rc-menu/lib/interface";
import { Menu, Layout } from "antd";
import { useRouter } from "next/navigation";
import { useStyles } from "./Style/styles";

const InstructorHeader = () => {
    const { styles } = useStyles();
    const { Header } = Layout;
    const [activeTab, setActiveTab] = useState("1");
    const router = useRouter();

    const menuItems = [
        { key: "1", label: "Dashboard" },
        { key: "2", label: "Profile" }
    ];

    const handleMenuClick = (e: MenuInfo) => {
        setActiveTab(e.key);
        if (e.key === "1") {
            router.push("/instructor");
        } else if (e.key === "2") {
            router.push("/instructor/profile");
        }
    };

    return (
        <Header className={styles.Navbar}>
            <div className={styles.NavTitle}>OLP</div>
            <Menu
                theme="dark"
                mode="horizontal"
                selectedKeys={[activeTab]}
                onClick={handleMenuClick}
                items={menuItems}
                className={styles.Menu}
            />
        </Header>
    );
};

export default InstructorHeader;
