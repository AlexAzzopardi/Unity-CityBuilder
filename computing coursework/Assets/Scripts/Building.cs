using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    Vector3 pos_click;
    Vector3 pos_mouse;

    public GameObject road_temp_object;
    public GameObject road_perm_object;
    public GameObject road_temp_placer;
    GameObject road_placer;
    public GameObject road_perm_placer;

    public GameObject house_temp_object;
    public GameObject house_perm_object;
    GameObject house_placer;

    public GameObject wood_harvester;
    public GameObject wood_harvester_placer;
    bool wood_harvesting = true;

    string building;
    string rot_building = "north";
    string dir;

    bool drawing_road = false;
    bool drawing = false;
    bool road_first = true;
    bool collide = false;

    float x_dif;
    float z_dif;

    Vector3 pos_zero = new Vector3(0, 0, 0);
    Quaternion rot_zero = Quaternion.Euler(0, 0, 0);
    Quaternion rot_quarter = Quaternion.Euler(0, 90, 0);
    Quaternion rot_half = Quaternion.Euler(0, 90, 0);
    Quaternion building_rotation = Quaternion.Euler(0, 0, 0);


    void Start()
    {
        building = "nothing";
        road_perm_placer = Instantiate(road_perm_placer, pos_zero, rot_zero);
    }

    void collide_detecting(bool obstacle)
    {
        collide = obstacle;
    }



    void Update()
    {
        pos_mouse = get_world_point();
        if (Input.GetKeyDown("j") == true && building != "road")
        {
            building = "road";
        }
        else if (Input.GetKeyDown("j") == true && building == "road")
        {
            building = "nothing";
        }
        else if (Input.GetKeyDown("h") == true && building != "house")
        {
            building = "house";
        }
        else if (Input.GetKeyDown("h") == true && building == "house")
        {
            building = "nothing";
        }
        else if (Input.GetKeyDown("k") == true && building != "wood_harvest")
        {
            building = "wood_harvest";
        }
        else if (Input.GetKeyDown("k") == true && building == "wood_harvest")
        {
            building = "nothing";
        }


        if (building == "road")
        {
            if (Input.GetMouseButtonDown(0) && drawing_road == false)
            {
                drawing_road = true;
                Destroy(road_placer);
                pos_click = pos_mouse;
            }

            if (Input.GetMouseButtonDown(1) && drawing_road == true)
            {
                drawing_road = false;
                drawing = false;
                road_first = true;
            }


            if (drawing_road == false)
            {
                Destroy(road_placer);
                road_placer = Instantiate(road_temp_placer, pos_mouse, rot_zero);
                Instantiate(road_temp_object, pos_mouse, rot_zero, road_placer.transform);
            }

            else {
                x_dif = pos_mouse[0] - pos_click[0];
                z_dif = pos_mouse[2] - pos_click[2];

                Destroy(road_placer);
                road_placer = Instantiate(road_temp_placer, pos_mouse, rot_zero);

                if (x_dif >= 0 && z_dif >= 0)
                {
                    dir = "northeast";
                }
                else if (x_dif >= 0 && z_dif <= 0)
                {
                    dir = "southeast";
                }
                else if (x_dif <= 0 && z_dif <= 0)
                {
                    dir = "southwest";
                }
                else if (x_dif <= 0 && z_dif >= 0)
                {
                    dir = "northwest";
                }

                if (road_first == true)
                {
                    Instantiate(road_temp_object, pos_click, rot_zero, road_placer.transform);
                }

                if (Input.GetMouseButtonDown(0) && drawing == true && collide == false)
                {
                    if (road_first == true)
                    {
                        Instantiate(road_perm_object, new Vector3(pos_click[0], 0, pos_click[2]), rot_zero, road_perm_placer.transform);
                        road_first = false;
                    }

                    if (dir == "northeast")
                    {
                        for (int i = 1; i <= z_dif; i++)
                        {
                            Instantiate(road_perm_object, new Vector3(pos_click[0], 0, pos_click[2] + i), rot_zero, road_perm_placer.transform);
                        }
                        for (int i = 1; i <= x_dif; i++)
                        {
                            Instantiate(road_perm_object, new Vector3(pos_click[0] + i, 0, pos_click[2] + z_dif), rot_quarter, road_perm_placer.transform);
                        }
                    }
                    else if (dir == "southeast")
                    {
                        for (int i = -1; i >= z_dif; i--)
                        {
                            Instantiate(road_perm_object, new Vector3(pos_click[0], 0, pos_click[2] + i), rot_zero, road_perm_placer.transform);
                        }
                        for (int i = 1; i <= x_dif; i++)
                        {
                            Instantiate(road_perm_object, new Vector3(pos_click[0] + i, 0, pos_click[2] + z_dif), rot_quarter, road_perm_placer.transform);
                        }
                    }
                    else if (dir == "southwest")
                    {
                        for (int i = -1; i >= z_dif; i--)
                        {
                            Instantiate(road_perm_object, new Vector3(pos_click[0], 0, pos_click[2] + i), rot_zero, road_perm_placer.transform);
                        }
                        for (int i = -1; i >= x_dif; i--)
                        {
                            Instantiate(road_perm_object, new Vector3(pos_click[0] + i, 0, pos_click[2] + z_dif), rot_quarter, road_perm_placer.transform);
                        }
                    }
                    else if (dir == "northwest")
                    {
                        for (int i = 1; i <= z_dif; i++)
                        {
                            Instantiate(road_perm_object, new Vector3(pos_click[0], 0, pos_click[2] + i), rot_zero, road_perm_placer.transform);
                        }
                        for (int i = -1; i >= x_dif; i--)
                        {
                            Instantiate(road_perm_object, new Vector3(pos_click[0] + i, 0, pos_click[2] + z_dif), rot_quarter, road_perm_placer.transform);
                        }
                    }
                    pos_click = pos_mouse;
                }

                else {
                    if (dir == "northeast")
                    {
                        for (int i = 1; i <= z_dif; i++)
                        {
                            Instantiate(road_temp_object, new Vector3(pos_click[0], 0, pos_click[2] + i), rot_zero, road_placer.transform);
                        }
                        for (int i = 1; i <= x_dif; i++)
                        {
                            Instantiate(road_temp_object, new Vector3(pos_click[0] + i, 0, pos_click[2] + z_dif), rot_quarter, road_placer.transform);
                        }
                    }
                    else if (dir == "southeast")
                    {
                        for (int i = -1; i >= z_dif; i--)
                        {
                            Instantiate(road_temp_object, new Vector3(pos_click[0], 0, pos_click[2] + i), rot_zero, road_placer.transform);
                        }
                        for (int i = 1; i <= x_dif; i++)
                        {
                            Instantiate(road_temp_object, new Vector3(pos_click[0] + i, 0, pos_click[2] + z_dif), rot_quarter, road_placer.transform);
                        }
                    }
                    else if (dir == "southwest")
                    {
                        for (int i = -1; i >= z_dif; i--)
                        {
                            Instantiate(road_temp_object, new Vector3(pos_click[0], 0, pos_click[2] + i), rot_zero, road_placer.transform);
                        }
                        for (int i = -1; i >= x_dif; i--)
                        {
                            Instantiate(road_temp_object, new Vector3(pos_click[0] + i, 0, pos_click[2] + z_dif), rot_quarter, road_placer.transform);
                        }
                    }
                    else if (dir == "northwest")
                    {
                        for (int i = 1; i <= z_dif; i++)
                        {
                            Instantiate(road_temp_object, new Vector3(pos_click[0], 0, pos_click[2] + i), rot_zero, road_placer.transform);
                        }
                        for (int i = -1; i >= x_dif; i--)
                        {
                            Instantiate(road_temp_object, new Vector3(pos_click[0] + i, 0, pos_click[2] + z_dif), rot_quarter, road_placer.transform);
                        }
                    }
                }
                drawing = true;
            }
        }
        else if (building != "road")
        {
            drawing_road = false;
            drawing = false;
            road_first = true;
            Destroy(road_placer);
        }



        if (building == "house")
        {
            Destroy(house_placer);
<<<<<<< HEAD
            house_placer = Instantiate(house_temp_object, new Vector3(pos_mouse[0] + 0.5f, 0.59f, pos_mouse[2] + 0.5f), building_rotation);
            if (Input.GetMouseButtonDown(0) && collide == false)
            {
                Instantiate(house_perm_object, new Vector3(pos_mouse[0] + 0.5f,0.59f, pos_mouse[2] + 0.5f), building_rotation);
=======
            house_placer = Instantiate(house_temp_object, new Vector3(pos_mouse[0] + 0.5f, 0.8f, pos_mouse[2] + 0.5f), building_rotation);
            if (Input.GetMouseButtonDown(0) && collide == false)
            {
                Instantiate(house_perm_object, new Vector3(pos_mouse[0] + 0.5f, 0.8f, pos_mouse[2] + 0.5f), building_rotation);
>>>>>>> 74918ef8aa9e8421ea05e26a4be509be5bb61d5a
            }

            if (Input.GetKeyDown("r"))
            {
                if (rot_building == "north")
                {
                    rot_building = "east";
                    building_rotation = Quaternion.Euler(0, 90, 0);
                }
                else if (rot_building == "east")
                {
                    rot_building = "south";
                    building_rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (rot_building == "south")
                {
                    rot_building = "west";
                    building_rotation = Quaternion.Euler(0, 270, 0);
                }
                else if (rot_building == "west")
                {
                    rot_building = "north";
                    building_rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
        else if (building != "house")
        {
            Destroy(house_placer);
        }

        if (building == "wood_harvest")
        {
            if (wood_harvesting == true)
            {
                pos_click = pos_mouse;
            }

            if (Input.GetMouseButtonDown(0) && wood_harvesting == false)
            {
                wood_harvesting = true;
                pos_click = pos_mouse;
            }

            else if (Input.GetMouseButtonDown(0) && wood_harvesting == true)
            {
                wood_harvesting = false;
                pos_click = pos_mouse;
            }

            if (Input.GetMouseButtonDown(1) && wood_harvesting == false)
            {
                wood_harvesting = true;
            }

            Destroy(wood_harvester_placer);
            wood_harvester_placer = Instantiate(wood_harvester, new Vector3((pos_click[0] + pos_mouse[0]) / 2, 0.25f, (pos_click[2] + pos_mouse[2]) / 2), rot_zero);
            wood_harvester_placer.transform.localScale = new Vector3(Mathf.Abs(pos_click[0] - pos_mouse[0]) + 1, 0.3f, Mathf.Abs(pos_click[2] - pos_mouse[2]) + 1);
        }
        else if (building != "wood_harvest")
        {
            if (wood_harvester_placer != null)
            {
                Destroy(wood_harvester_placer);
            }
            wood_harvesting = true;
        }
    }



    Vector3 get_world_point()
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            pos_mouse = hit.point;
            pos_mouse[0] = Mathf.Round(pos_mouse[0]);
            pos_mouse[1] = 0;
            pos_mouse[2] = Mathf.Round(pos_mouse[2]);
            return pos_mouse;
        }
        return Vector3.zero;
    }
}