import React, { useState } from "react";
import { Menu, Layout } from "antd";
import { useStyles } from "./Style/styles";

const InstructorHeader = () => {
    const { styles } = useStyles();
    const { Header } = Layout;
    const [activeTab, setActiveTab] = useState("1");

    const menuItems = [
        { key: "1", label: "Dashboard" },
        { key: "2", label: "Profile" }
    ];

    return (
        <Header className={styles.Navbar}>
            <div className={styles.NavTitle}>OLP</div>
            <Menu
                theme="dark"
                mode="horizontal"
                selectedKeys={[activeTab]}
                onClick={(e) => setActiveTab(e.key)}
                items={menuItems}
                className={styles.Menu}
            />
        </Header>
    );
};

export default InstructorHeader;
